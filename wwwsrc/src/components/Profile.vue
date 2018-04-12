<template>
    <div>
        <Navbar></Navbar>
        <div class="profile">
            <div v-if="libraries.length == 0">
                <h2>Add a Library to get started!</h2>
            </div>
            <div class="row libraries">
                <div v-for="library in libraries" class="col-sm-5 library">
                    <div class="card">
                        <div class="card-body" @click="getLibraryBooks(library.id)" data-toggle="modal" :data-target="'#' + library.id">
                            <h2>{{library.name}}</h2>
                            <h4>{{library.description}}</h4>
                            <div v-if="library.public == 'true'" class="text-muted"><small>Public</small></div>
                            <div v-if="library.public == 'false'" class="text-muted"><small>Private</small></div>
                        </div>
                    </div>

                    <!-- Modal -->
                    <div class="modal fade" :id="library.id" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLongTitle">{{library.name}}</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div v-if="libraryBooks.length == 0">
                                        <h3>Add a Book to your Library from the Home Page</h3>
                                    </div>
                                    <div v-for="lb in libraryBooks" class="books">
                                        <img :src="lb.cover" class="cover">
                                        <div class="text">
                                            <h6>
                                                <b>{{lb.title}}</b>
                                            </h6>
                                            <small>{{lb.author}}</small>
                                            <br>
                                            <small>{{lb.genre}}</small>
                                        </div>
                                        <small class="synopsis">{{lb.synopsis}}</small>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div v-if="deleteButton == true">
                                        <h5>Delete this Library?</h5>
                                        <button @click="deleteLibrary(library.id), deleteButton = !deleteButton" class="btn deletebtn btn-danger" data-dismiss="modal">Yep, Delete it!</button>
                                        <button @click="deleteButton = !deleteButton" class="btn deletebtn btn-secondary">Just Kidding, Keep it.</button>
                                    </div>
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    <button @click="deleteButton = !deleteButton" type="button" class="btn btn-danger">Delete Library</button>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>



        </div>
    </div>
</template>

<script>
    import Navbar from './Navbar'
    export default {
        name: 'Profile',
        data() {
            return {
                deleteButton: false

            }
        },
        mounted() {
            this.$store.dispatch('authProfile')
            this.$store.dispatch('onProfile')
            this.$store.dispatch('getLibraries', this.$store.state.user.id)
        },
        methods: {
            getLibraryBooks(libraryId) {
                this.$store.dispatch('getLibraryBooks', libraryId)
            },
            deleteLibrary(libraryId) {
                this.$store.dispatch('deleteLibrary', { userId: this.$store.state.user.id, libraryId: libraryId})
            }
        },
        components: {
            Navbar
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            libraries() {
                return this.$store.state.libraries
            },
            libraryBooks() {
                return this.$store.state.libraryBooks
            }
        }
    }
</script>

<style scoped>
    .profile {
        background-color: rgb(33, 197, 121);
        min-height: 90vh;
        padding-top: 10px;
    }

    .libraries {
        display: flex;
        justify-content: center;
    }

    .card-body {
        background-color: #ffffff;
        background-image: url("https://www.transparenttextures.com/patterns/notebook-dark.png");
        cursor: pointer;
    }

    .card {
        margin-bottom: 10px;
    }

    .books {
        display: flex;
        flex-direction: row
    }

    .cover {
        height: 15vh;
        margin: 3px;
    }

    .synopsis,
    .text {
        border-left: indigo 5px solid;
        margin: 3px;
    }

    .deletebtn {
        margin: 3px;
    }
</style>