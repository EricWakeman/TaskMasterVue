<template>
  <div class="container-fluid">
    <div class="row text-center ">
      <div class="col-12 p-2">
        <h1>Hello {{ user.nickname }}</h1>
      </div>
      <div class="col-12">
        <h3>Make a new List?</h3> <span class="mdi mdi-home"></span>
      </div>
    </div>
    <div class="row">
      <div class="col-3">
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { listsService } from '../services/ListsService'
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiAccount } from '@mdi/js'
export default {
  setup() {
    onMounted(() =>
      listsService.getAll(AppState.account.id))
    return {
      lists: computed(() => AppState.lists),
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
}
</style>
