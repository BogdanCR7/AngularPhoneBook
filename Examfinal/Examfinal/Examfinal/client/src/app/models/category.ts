export class Category{
   id: number;
   name: string;
   contactsCount: number;
   constructor(id:number,name:string,contactsnumber:number) {
      this.id = id;
      this.name = name;
      this.contactsCount = contactsnumber;
   }
   
}