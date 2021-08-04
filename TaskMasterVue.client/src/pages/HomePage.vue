<template>
  <div class="container-fluid">
    <div class="row text-center ">
      <div class="col-12 p-2">
        <h1>Hello {{ user.nickname }}</h1>
      </div>
      <div class="col-12">
        <h3>Make a new List?</h3> <im alt="Create List" class=" newList grow hoverable mdi mdi-text-box-plus" data-toggle="modal" data-target="#createList">
        </im>
      </div>
    </div>
    <div class="row pt-5 masonry-with-columns">
      <div class="col-md-3" v-for="l in lists" :key="l.id">
        <List :list="l" />
      </div>
    </div>
  </div>
  <CreateList />
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { listsService } from '../services/ListsService'
import { tasksService } from '../services/TasksService'
import Pop from '../utils/Notifier'
export default {
  setup() {
    onMounted(async() => {
      try {
        await listsService.getAll()
        await tasksService.getAll()
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      lists: computed(() => AppState.lists),
      tasks: computed(() => AppState.tasks),
      account: computed(() => AppState.account),
      user: computed(() => AppState.user)
    }
  }

}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }

  .masonry-with-columns {
  columns: 6 200px;
  column-gap: 1rem;
  div {
    width: 150px;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
  }

}
.newList{
  font-size: 3rem !important;
}
}

</style>
