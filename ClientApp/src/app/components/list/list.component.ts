import { Component, OnInit } from '@angular/core';
import { CommonModule, NgClass } from '@angular/common';
import { TaskService } from '../../services/taskservice';
import { TmplAstIfBlockBranch } from '@angular/compiler';
import { HttpClient } from '@angular/common/http';
import { User } from '../../models/user';
import { FormsModule } from '@angular/forms';
import { Task } from '../../models/todoitem';

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
  tasks: Task[] = [];

  constructor(private taskService: TaskService,private http: HttpClient){}

  ngOnInit(): void {
    this.taskService.GetTasks().subscribe({
      next: response => {this.tasks = response
      console.log(this.tasks);
    }
      ,
      error: error => console.log(error),
      complete: () => console.log('Request has compleated')
    });    
  }

  toggle(task:any){
    console.log(task);
  }

  addTask(){
    this.taskService.createNew(new Task(0, this.title, "", false)).subscribe({
      next: response => this.tasks.push(response),
      error: error => console.log(error),
      complete: ()=> console.log('complete!')
    });
    
    this.title ='';
  }

}
