import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { User } from '../models/user';
import { Task } from '../models/todoitem';
import { environment } from '../../../environment/environment';

@Injectable({
  providedIn: 'root',
})
export class TaskService {

  baseUrl = environment.apiUrl;

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

    
     return this.http.get(this.baseUrl+'task/get_all',{
        headers: this.GetHeaders()
    }).pipe(
      map( (response:any) => response.map((t:any) => 
                    new Task(t.id, t.title, t.description, t.isDone, t.createdDate))
    ));    
  }
  CreateNew(task:Task){
     return this.http.post(this.baseUrl+'task/add',task,{
        headers: this.GetHeaders()
    }).pipe(
      map( (t:any) => new Task(t.id, t.title, t.description, t.isDone, t.createdDate)
    ));    
  }
  Edit(task:Task):Observable<any>{
     return this.http.post(this.baseUrl+'task/edit',task,{
        headers: this.GetHeaders()
    });
  }
  Remove(task: Task):Observable<any>{
     return this.http.post(this.baseUrl+'task/delete',task,{
        headers: this.GetHeaders()
    });
  }
}
