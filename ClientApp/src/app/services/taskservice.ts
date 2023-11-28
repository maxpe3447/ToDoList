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

  GetTasks():Observable<Task[]>{

    const userString = localStorage.getItem('user');
    if(!userString){
      //userString = "";
      throw Error("invalid user token");
    }
    const user: User = JSON.parse(userString);
    const headerDict = {
        'Authorization': 'Bearer '+ user.token
      }
     return this.http.get('https://localhost:7125/api/'+'task/get_all',{
        headers: headerDict
    }).pipe(
      map( (response:any) => response.map((t:any) => 
                    new Task(t.id, t.title, t.description, t.isDone ))
    ));    
  }
  createNew(task:Task){
    const userString = localStorage.getItem('user');
    if(!userString){
      //userString = "";
      throw Error("invalid user token");
    }
    const user: User = JSON.parse(userString);
    const headerDict = {
        'Authorization': 'Bearer '+ user.token
      }
     return this.http.post('https://localhost:7125/api/'+'task/add',task,{
        headers: headerDict
    }).pipe(
      map( (t:any) => new Task(t.id, t.title, t.description, t.isDone )
    ));    
  }
}
