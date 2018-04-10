<template>
  <div>
    <Navbar></Navbar>
    <div class="home">
      <div class="row">
        <div v-for="(book, id) in books" class="col-sm-3 book">
          <Book :book="book" :id="id"></Book>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Navbar from './Navbar'
  import Book from './Book'
  export default {
    name: 'Home',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getBooks')
      this.$store.dispatch('offProfile')
    },
    computed: {
      books() {
        return this.$store.state.books
      }
    },
    components: {
      Navbar,
      Book
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

</style>