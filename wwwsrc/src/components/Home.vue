<template>
  <div>
    <Navbar></Navbar>
    <div class="home">
      <div class="row">
        <div class="col-sm-12 flexy">
          <button class="btn btn-link" @click="viewBooks = true">View Books</button>
          <button class="btn btn-link" @click="viewBooks = false">View Public Libraries</button>
        </div>
        <div v-if="viewBooks == true" v-for="(book, id) in books" class="col-sm-3 book">
          <Book :book="book" :id="id"></Book>
        </div>
        <div v-if="viewBooks == false" v-for="(library, id) in publicLibraries" class="col-sm-6 book">
          <Library :library="library" :id="id"></Library>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Navbar from './Navbar'
  import Book from './Book'
  import Library from './Library'
  export default {
    name: 'Home',
    data() {
      return {
        viewBooks: true
      }
    },
    mounted() {
      this.$store.dispatch('getBooks')
      this.$store.dispatch('getPublicLibraries')
      this.$store.dispatch('offProfile')
    },
    computed: {
      books() {
        return this.$store.state.books
      },
      publicLibraries() {
        return this.$store.state.publicLibraries
      }
    },
    components: {
      Navbar,
      Book,
      Library
    }
  }
</script>

<style scoped>
  .home {
    min-height: 90vh;
    background-color: rgb(98, 186, 197)
  }

  .row {
    width: 100%
  }

  .book:hover {
    cursor: pointer;
  }

  .flexy {
    display: flex;
    justify-content: flex-start;
  }

  .btn-link {
    color: white;
    font-weight: 700;
  }
</style>