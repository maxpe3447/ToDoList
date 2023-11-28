import { Component, OnInit } from '@angular/core';
import { CommonModule, NgClass } from '@angular/common';
import { TaskService } from '../../services/taskservice';
import { FormsModule } from '@angular/forms';
import { Task } from '../../models/todoitem';
import { AccountService } from '../../services/accountService';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [CommonModule, FormsModule, NgClass],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css',
  providers:[TaskService]
})
export class ListComponent implements OnInit{
  title:string ="";
  private tasks: Task[] = [];
  username:String = ""
  isNewStart:boolean = true;
  constructor(private taskService: TaskService, private accountService:AccountService){}

  getTasks(){
    if(this.isNewStart){
      return this.tasks.sort((a,b)=>-this.compareDates(a.DateTime, b.DateTime))
    }
    return this.tasks.sort((a,b)=>this.compareDates(a.DateTime, b.DateTime))
  }

  private compareDates = (a: Date, b: Date): number => {
    if (a < b) return -1;
    if (a > b) return 1;
  
    return 0;
  };
  
  ngOnInit(): void {
    this.accountService.currentUser$.subscribe({
      next: val => this.username = val?.username ?? ""
      
    })

    this.taskService.GetTasks().subscribe({
      next: response => this.tasks = response      ,
      error: error => console.log(error),
      complete: () => console.log('Request {GetTasks} has compleated')
    });    
  }

  togglecheck(task:Task){
    task.IsDone = !task.IsDone;
    this.editTask(task);
  }
  toggleSortCheck(){
    this.isNewStart = !this.isNewStart;
  }
  addTask(){
    this.taskService.CreateNew(new Task(0, this.title, "", false, new Date())).subscribe({
      next: response => this.tasks.push(response),
      error: error => console.log(error),
      complete: ()=> console.log('Request {CreateNew} has compleated!')
    });
    
    this.title ='';
  }
  startEdit(task:Task){
    task.isEditMode = true;
  }
  editTask(task:Task){
    this.taskService.Edit(task).subscribe();
    task.isEditMode = false;
  }
  remove(task: Task){
    this.taskService.Remove(task).subscribe();
    const index = this.tasks.indexOf(task);
    this.tasks.splice(index, 1);
  }
  saveEditToggle(task:Task){
    if(task.isEditMode){
      this.editTask(task);
      return;
    }
    this.startEdit(task);
  }
}
