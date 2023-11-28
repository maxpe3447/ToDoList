export class Task{
    Id: Number = 0;
    Title: string="";
    Description: string="";
    IsDone: boolean = false;
    isEditMode: boolean = false;
    DateTime: Date = new Date();
    constructor(id: Number, title:string, description:string, isDone:boolean, dateTime:Date){
        this.Id = id;
        this.Description = description;
        this.Title = title;
        this.IsDone = isDone;
        this.DateTime = dateTime;
    }
}