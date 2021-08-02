import { AppState } from '../AppState'
import { Task } from '../models/Task'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class TasksService {
  async getAll() {
    const res = await api.get('api/tasks')
    AppState.tasks = res.data.map(t => new Task(t))
    logger.log(res.data)
  }

  async getAllByListId(listId) {
    const res = await api.get('api/lists/' + listId + '/tasks')
    AppState.tasks = res.data.map(t => new Task(t))
  }

  async getOne(taskId) {
    const res = await api.get('api/tasks/' + taskId)
    AppState.activeTask = new Task(res.data)
  }

  async createTask(taskData) {
    const res = await api.post('api/tasks', taskData)
    AppState.tasks.push(new Task(res.data))
  }

  async updateTask(taskData) {
    const res = await api.put('api/tasks/' + taskData.id, taskData)
    AppState.tasks = AppState.tasks.filter(l => l.id !== taskData.id)
    AppState.tasks.push(new Task(res.data))
  }

  async deleteTask(taskId) {
    await api.delete('api/tasks/' + taskId)
    AppState.tasks = AppState.tasks.filter(l => l.id !== taskId)
  }
}
export const tasksService = new TasksService()
