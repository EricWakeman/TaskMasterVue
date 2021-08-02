<template>
  <div class="card my-2 shadow rounded justify-content-end d-flex">
    <label for="Task Completed">

      {{ task.title }}

      <input type="checkbox" name="Task Completed" class="hoverable">
    </label>
    <img src="src\assets\img\trash-can.png" alt="delete task" class="hoverable grow trash">
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
export default {
  props: { task: { type: Object, required: true } },
  setup() {
    const state = reactive({
      currentTask: {}
    })
    return {
      state
    }
  }
}
</script>

<style>
label {
  display: block;
  padding-left: 15px;
  text-indent: -15px;
}
input {
  width: 13px;
  height: 13px;
  padding: 0;
  margin:0;
  vertical-align: bottom;
  position: relative;
  top: -1px;
  *overflow: hidden;
}
.trash{
  height: 1.5rem;
  width: 1.5rem;
  position: absolute;
  right: 1rem;
}
</style>
