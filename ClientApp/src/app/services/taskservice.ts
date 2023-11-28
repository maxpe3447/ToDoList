import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { User } from '../models/user';
import { Task } from '../models/todoitem';

@Injectable({
  providedIn: 'root',
})
export class TaskService {

  baseUrl = 'https://localhost:7125/api/';

  constructor(private http:HttpClient) { }

  private GetHeaders(){
    const userString = localStorage.getItem('user');
    if(!userString){
      //userString = "";
      throw Error("invalid user token");
    }
    const user: User = JSON.parse(userString);
    return {
        'Authorization': 'Bearer '+ user.token
      }
  }

  GetTasks():Observable<Task[]>{

    
     return this.http.get('https://localhost:7125/api/'+'task/get_all',{
        headers: this.GetHeaders()
    }).pipe(
      map( (response:any) => response.map((t:any) => 
                    new Task(t.id, t.title, t.description, t.isDone ))
    ));    
  }
  CreateNew(task:Task){
     return this.http.post('https://localhost:7125/api/'+'task/add',task,{
        headers: this.GetHeaders()
    }).pipe(
      map( (t:any) => new Task(t.id, t.title, t.description, t.isDone )
    ));    
  }
  Edit(task:Task):Observable<any>{
     return this.http.post('https://localhost:7125/api/'+'task/edit',task,{
        headers: this.GetHeaders()
    });
  }
  Remove(task: Task):Observable<any>{
     return this.http.post('https://localhost:7125/api/'+'task/delete',task,{
        headers: this.GetHeaders()
    });
  }
}
