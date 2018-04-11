<template>
    <div class="book">
        <div data-toggle="modal" :data-target="'#'+id">
            <img class="cover" :src="book.cover">
            <h5 class="title">
                <b>{{book.title}}</b>
            </h5>
            <p>{{book.author}}</p>
        </div>
        <!-- Modal -->
        <div class="modal fade" :id="id" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="flexy">
                            <h4 class="modal-title" id="exampleModalLongTitle">{{book.title}}</h4>
                            <p>{{book.author}}</p>
                        </div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div>
                            <img class="cover2" :src="book.cover">
                        </div>
                        <div class="flexy">
                            <h4>Genre:</h4>
                            <h6>
                                <b>{{book.genre}}</b>
                            </h6>
                            <h4>Synopsis:</h4>
                            <h6>
                                <b>{{book.synopsis}}</b>
                            </h6>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <div class="dropdown">
                            <button @click="getLibraries" class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
                                aria-haspopup="true" aria-expanded="false">
                                Add to a Library
                            </button>
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                <div v-if="libraries.length == 0">
                                    <p>No Libraries!</p>
                                </div>
                                <div class="dropdown-item" v-for="library in libraries">
                                    <p @click="addToLibrary(book.id, library.id)">{{library.name}}</p>
                                </div>
                            </div>
                        </div>
                        <div v-if="book.userId == user.id">
                            <button @click="deleteButton = !deleteButton" type="button" class="btn btn-danger">Delete Book</button>
                            <div v-if="deleteButton == true">
                                <h5 class="deletebtn">Delete this Book?</h5>
                                <button @click="deleteBook(book.id), deleteButton = !deleteButton" class="btn deletebtn btn-danger" data-dismiss="modal">Yep, Delete it!</button>
                                <button @click="deleteButton = !deleteButton" class="btn deletebtn btn-secondary">Just Kidding, Keep it.</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
    export default {
        name: 'Book',
        data() {
            return {
                deleteButton: false
            }
        },
        mounted() {
            this.$store.dispatch('authCheck')
        },
        methods: {
            getLibraries() {
                this.$store.dispatch('getLibraries', this.$store.state.user.id)
            },
            addToLibrary(bookId, libraryId) {
                this.$store.dispatch('addToLibrary', { bookId: bookId, libraryId: libraryId, userId: this.$store.state.user.id })
            },
            deleteBook(bookId) {
                this.$store.dispatch('deleteBook', bookId)
            }
        },
        components: {

        },
        computed: {
            libraries() {
                return this.$store.state.libraries
            },
            user() {
                return this.$store.state.user
            }
        },
        props: ['book', 'id']
    }
</script>

<style scoped>
    .cover {
        height: 20vh;
        margin: 5px;
    }

    .cover2 {
        height: 40vh;
        margin: 5px;
    }

    .title {
        margin-left: 2px;
        margin-right: 2px;
    }

    .flexy {
        display: flex;
        flex-direction: column;
        align-items: flex-start
    }

    .modal-body {
        display: flex;
        flex-direction: row
    }

    .deletebtn {
        margin: 3px;
    }
</style>