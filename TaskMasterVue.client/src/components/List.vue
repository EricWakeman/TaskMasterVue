<template>
  <div class="card mt-3 ">
    <div class="card-header">
      <span>
        {{ list.title }}
      </span>
    </div>
    <div class="card-body">
      <Task v-for="t in tasks" :key="t.id" :task="t" />
    </div>
    <form class="card-footer" @submit.prevent="createTask" :id="taskFormId">
      <div class="form-group">
        <label for="Task Name" aria-readonly="Task Name"></label>
        <input type="text"
               class="form-control"
               aria-describedby="helpId"
               placeholder="New task name..."
               v-model="state.newTask.title"
        >
        <button type="submit" class="btn btn-primary btn-sm mt-2">
          Create task
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import Pop from '../utils/Notifier'
import { tasksService } from '../services/TasksService'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: { list: { type: Object, required: true } },
  setup(props) {
    const state = reactive({ newTask: { } })
    const taskFormId = ('task-form-' + props.list.id)
    return {
      tasks: computed(() => AppState.tasks.filter(t => t.listId === props.list.id)),
      state,
      taskFormId,
      async createTask() {
        try {
          state.newTask.listId = props.list.id
          await tasksService.createTask(state.newTask)
          state.newTask.title = ''
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style>
.card{
  color: black;
}
</style>
