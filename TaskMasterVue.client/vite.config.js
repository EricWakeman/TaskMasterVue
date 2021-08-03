import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  build: {
    outDir: '../TaskMasterVue/wwwroot',
    sourcemap: false,
    rollupOptions: {
      external: ['src/assets/img/trash-can.png']
    }
  },
  server: {
    port: 8080
  }
})
