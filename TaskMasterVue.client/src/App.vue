<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    const state = { newTask: { title: 'client be updatin a tasky boi', id: 5 } }
    return {
      state,
      appState: computed(() => AppState),
      account: computed(() => AppState.account)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

</style>
