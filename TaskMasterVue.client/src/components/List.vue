<template>
  <div class="card">
    <div class="card-header">
      {{ list.title }}
    </div>
    <div class="card-body">
    </div>
  </div>
</template>

<script>
export default {
  props: { list: { type: Object, required: true } }
}
</script>

<style>

</style>
