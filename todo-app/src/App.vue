<template>
  <div>
      <todo-app></todo-app>
  </div>
</template>

<script>
import TodoApp from './components/TodoApp.vue'

export default {
  name:'App',
  components: {
    TodoApp,
  }
}
</script>

<style lang="css">
  @import url('./css/Bootstrap/bootstrap.css');
  @import url('./fontawesome/css/all.css');
  
</style>
