import { AppState } from '../AppState'
import { List } from '../models/List'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ListsService {
  async getAll() {
    const res = await api.get('api/lists')
    AppState.lists = res.data.map(l => new List(l))
  }

  async getListById(id) {
    const res = await api.get('api/lists/' + id)
    AppState.activeList = new List(res.data)
  }

  async createList(listData) {
    const res = await api.post('api/lists', listData)
    AppState.lists.push(new List(res.data))
  }

  async updateList(listData) {
    const res = await api.put('api/lists/' + listData.id, listData)
    AppState.lists = AppState.lists.filter(l => l.id !== listData.id)
    AppState.lists.push(new List(res.data))
  }

  async deleteList(listId) {
    await api.delete('api/lists/' + listId)
    AppState.lists = AppState.lists.filter(l => l.id !== listId)
  }
}
export const listsService = new ListsService()
