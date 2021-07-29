<template>
  <div class="card">
    {{ task.title }}
  </div>
</template>

<script>
export default {
  props: { task: { type: Object, required: true } }
}
</script>

<style>

</style>
