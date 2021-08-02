<template>
  <!-- Modal -->
  <div class="modal fade"
       id="createList"
       tabindex="-1"
       role="dialog"
       aria-labelledby="createListModal"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <form class="modal-content" @submit.prevent="createList" id="list-form">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLongTitle">
            Modal title
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body form-group">
          <label for="List Name" aria-readonly="List name">
          </label>
          <input class="form-control" type="text" v-model="state.newList.title" placeholder="New list name...">
        </div>
        <div class="modal-footer">
          <button type="submit" class="btn btn-primary">
            Create List
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { listsService } from '../services/ListsService'
import Pop from '../utils/Notifier'
import $ from 'jquery'
export default {
  setup() {
    const state = ({ newList: {} })
    return {
      state,
      createList() {
        try {
          listsService.createList(state.newList)
          $('#createList').modal('toggle')
          document.getElementById('list-form').reset()
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style scoped>
.modal-dialog{
  color: black;
}
</style>
