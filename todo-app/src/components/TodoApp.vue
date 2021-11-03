<template>
  <div class="container col-xl-8">
    <h2 class="text-center mt-5 title"> My Todo-s</h2>
    
    <div class="d-flex col-xl-12 bg-white" id="inputForm">
      <input type="text" class="col-xl-8 inputText" placeholder="Add news ..." v-model="task.taskName">
      <input type="date" class="col-xl-3 inputDate" v-model="task.createdDate">
      <button class="btn btn-primary col-xl-1" @click="addTask()">Add</button>
    </div>
     <br>
    <hr>
    <div class="d-flex content">
      <div class="d-flex col-xl-12 row filter">
        <div id="leftFilter" class="col-xl-6"></div>
        <div id="rightFilter" class="d-flex col-xl-6 " >
          <label for="cars" class="col-form-label text">Filter</label>
          <select name="cars" id="cars" class="form-control col-xl-3">
            <option value="volvo">Volvo</option>
            <option value="saab">Saab</option>
            <option value="opel">Opel</option>
            <option value="audi">Audi</option>
          </select>
          <label for="cars" class="col-form-label text">Sort</label>
          <select name="cars" id="sort" class="form-control col-xl-3">
            <option value="volvo">Volvo</option>
            <option value="saab">Saab</option>
            <option value="opel">Opel</option>
            <option value="audi">Audi</option>
          </select>
        </div>
        <div class="col-xl-12 checkTask">
          <div class="taskRow d-flex col-xl-12">
            <div class="col-xl-12 checkLeft">
              <div class=" task row " v-for="task in tasks" :key="task.taskId">
                <input type="checkbox" class="form-control col-xl-1 inputCheck" v-model="task.status">
                <label for="" class="col-form-label col-xl-8" :class="{'statusChecked' : task.status}">{{task.taskName}}</label>
                <div class="createdDate col-xl-2">
                   {{formatDate(task.createdDate)}}
                </div>
                <div class="col-xl-1 d-flex">
                  <i class="fa fa-pen container" @click="updateTask(task)"></i>
                  <i class="fa fa-trash container" @click="deleteTask(task.taskId)"></i>
                </div>
              </div>
            </div>
            <!-- <div class="col-xl-6 checkRight container text-center">
              <div class="createdDate">
                01/11/2021
              </div>
            </div> -->
          </div>
         
        </div>
      </div>
      <div class="d-flex">
        
      </div>
    </div>
   
  </div>
</template>

<script>
  import axios from 'axios'
  export default {
    data() {
      return {
        tasks:[],
        // date:[],
        task:{},
      }

    },
    methods: {
      formatDate(dateTime){
        var date = String(dateTime).substr(0,10);
        return date;
      },
      validate(){
        if(this.task.taskName === null || this.task.taskName === ""){
          alert('Bạn cần nhập Task Name');
          return false;
        }
        // if(this.task.createdDate === null || this.task.createdDate ==""){
        //   alert("Bạn chưa chọn ngày");
        //   return false;
        // }
        return true;
      },
      async loadData(){
        await axios.get('http://localhost:41813/api/task').then((result)=>{
          console.log(result.data);
          this.tasks = result.data;
        });
        for(var i=0; i<this.tasks.length;i++){
          this.tasks[i].createdDate = String(this.tasks[i].createdDate).substr(0,10);
        }
      },
      async addTask(){
        if(this.validate() == true){
          if(this.task.isUpdate == false){
            await axios.post('http://localhost:41813/api/task', this.task).then((result)=>{
              if(result.data > 0){
                alert("Thêm thành công!");
                this.loadData();
              }
            })
          }
         else{
            await axios.put('http://localhost:41813/api/task', this.task).then((result)=>{
              if(result.data > 0){
                alert("Sửa thành công!");
                this.loadData();
              }
            })
            this.task.isUpdate = false;
         }
        }
      },
      async deleteTask(taskId){
         await axios.delete('http://localhost:41813/api/task/'+taskId).then((result)=>{
            if(result.data > 0){
              alert("Xóa thành công!");
              this.loadData();
            }
          })
      },
      updateTask(task){
        this.task = task;
        this.task.isUpdate = true;
      }
    },
    async created() {
        this.task = new Object();
      await axios.get('http://localhost:41813/api/task').then((result)=>{
        console.log(result.data);
        this.tasks = result.data;
      });
      for(var i=0; i<this.tasks.length;i++){
        this.tasks[i].createdDate = String(this.tasks[i].createdDate).substr(0,10);
      }
      console.log(this.tasks);
    },
  }
</script>
    
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
*{
  background: #ebebeb;
}
#inputForm{
  padding-top: 8px;
  padding-bottom: 8px;
  border-radius: 10px;
}
.inputText, .inputDate{
  border: 0px;
  font-size: 16px;
  background:#fff;
}
.inputText, .inputDate:focus{
  outline: none !important;
  border: none !important;
}
.title{
  line-height: 42px;
  color: blue;
  padding:12px;
}
#rightFilter lable{
  margin-left: 15px !important;
  margin-right: 8px !important;
  width: 100px !important;
}
.inputCheck{
  width: 20px;
  height: 20px;
  margin: auto;
}
/* .createdDate{

} */
.taskRow{
  padding: 15px 0px !important;
}
.checkRight{
  align-items: center !important;
  display: flex;
}
/* .form-control:focus{
  border: 0px !important;
  outline: none !important;
} */
.text{
  margin-left: 12px;
  margin-right: 8px;
}
.statusChecked{
  text-decoration: line-through;
}
</style>
