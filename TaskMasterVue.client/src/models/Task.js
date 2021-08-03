export class Task {
  constructor(data) {
    this.id = data.id
    this.title = data.title
    this.creatorId = data.creatorId
    this.listId = data.listId
    this.completed = data.completed
  }
}
