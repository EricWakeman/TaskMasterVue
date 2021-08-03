<template>
  <div class="card my-2 shadow rounded justify-content-center d-flex ">
    <label for="Unfinished Task" class="ml-2" v-if="task.completed == false">

      {{ task.title }}

      <input
        type="checkbox"
        name="Task Completed"
        class="hoverable"
        v-model="state.currentTask.completed"
        @change="updateTask"
      >
    </label>
    <label for="Completed Task" class="ml-2 complete" v-if="task.completed == true">
      {{ task.title }}

      <input
        type="checkbox"
        name="Task Completed"
        class="hoverable"
        v-model="state.currentTask.completed"
        @change="updateTask"
        checked
      >
    </label>
    <i alt="delete task" class="hoverable grow trash mdi mdi-trash-can" @click="deleteTask(task.id)">
    </i>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { tasksService } from '../services/TasksService'
import Pop from '../utils/Notifier'
export default {
  props: { task: { type: Object, required: true } },
  setup(props) {
    const state = reactive({
      currentTask: props.task

    })
    // watch(() => state.currentTask.completed, () => { tasksService.updateTask(state.currentTask) })
    return {

      state,
      async  deleteTask(id) {
        try {
          if (await Pop.confirm()) {
            tasksService.deleteTask(id)
          }
        } catch (error) {
          Pop.toast(error, 'error', 'center')
        }
      },
      async updateTask() {
        try {
          await tasksService.updateTask(state.currentTask)
        } catch (error) {
          Pop.toast(error, 'error', 'center')
        }
      }
    }
  }
}
</script>

<style scoped>
label {
  display: block;
  padding-left: 15px;
  text-indent: -15px;
  font-family: 'EB Garamond', serif;

}
input {
  width: 13px;
  height: 13px;
  padding: 0;
  margin:0;
  vertical-align: bottom;
  position: relative;
  top: -4px;
  *overflow: hidden;
}
.trash{
  height: 1.5rem;
  width: 1.5rem;
  position: absolute;
  right: 1rem;
}
.complete{
  text-decoration: line-through;
}
</style>
