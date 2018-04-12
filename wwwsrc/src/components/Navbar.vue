<template>
    <div class="navbar">
        <h1 class="title">My&#8226;brary</h1>
        <h5 v-if="user.name" class="name">Happy Reading, {{user.name}}!</h5>
        <div class="navRight">
            <div v-if="!user.name">
                <button class="btn btn-light" @click=goToLogin>Login / Create Account</button>
            </div>
            <div v-if="user.name">
                <button class="btn btn-light" v-if="onProfile == true" data-toggle="modal" data-target="#addLibrary">Add a Library</button>
                <button class="btn btn-light" @click=goHome v-if="onProfile == true">Home</button>
                <button class="btn btn-light" v-if="onProfile == false" data-toggle="modal" data-target="#addBook">Add a Book</button>
                <button class="btn btn-light" @click=goToProfile v-if="onProfile == false">Profile</button>
                <button class="btn btn-light" @click=logout(user)>Logout</button>
            </div>
        </div>

        <!-- Library Modal -->
        <div class="modal fade" id="addLibrary" tabindex="-1" role="dialog" aria-labelledby="addLibraryCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Add a Library</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form class="form-group" @submit.prevent="createLibrary(name, description, publicBool, user)">
                            <input class="form-control" type="text" v-model="name" placeholder="Library Name" required>
                            <textarea class="form-control" type="text" v-model="description" placeholder="Description"></textarea>
                            <div class="flexy2"><p>Public &nbsp;</p><input type="checkbox" v-model="publicBool"></div> 
                            <button type="submit" class="btn btn-primary">Submit</button>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Book Modal -->
        <div class="modal fade" id="addBook" tabindex="-1" role="dialog" aria-labelledby="addBookCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Add a Book</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form class="form-group" @submit.prevent="createBook(title, author, genre, synopsis, cover, user)">
                            <input class="form-control" type="text" v-model="title" placeholder="Title" required>
                            <input class="form-control" type="text" v-model="author" placeholder="Author" required>
                            <select class="form-control" v-model="genre" required>
                                <option value="" selected disabled hidden class="text-muted">Genre</option>
                                <option value="Adult Fiction">Adult Fiction</option>
                                <option value="Autobiography">Autobiography</option>
                                <option value="Biography">Biography</option>
                                <option value="Children">Children</option>
                                <option value="Fantasy">Fantasy</option>
                                <option value="Fiction">Fiction</option>
                                <option value="Graphic Novel">Graphic Novel</option>
                                <option value="Historic Fiction">Historic Fiction</option>
                                <option value="Horror">Horror</option>
                                <option value="Mystery">Mystery</option>
                                <option value="Non-Fiction">Non-Fiction</option>
                                <option value="Romance">Romance</option>
                                <option value="Sci-Fi">Sci-Fi</option>
                                <option value="Thriller">Thriller</option> placeholder=""
                                <option value="Young Adult">Young Adult</option>
                                <option value="Other">Other</option>
                            </select>
                            <textarea class="form-control" type="text" v-model="synopsis" placeholder="Synopsis"></textarea>
                            <input class="form-control" type="text" v-model="cover" placeholder="Cover Image URL" required>
                            <small class="text-muted">Everyone will be able to see this.</small>
                            <br>
                            <button type="submit" class="btn btn-primary">Submit</button>
                        </form>
                        <div v-if="cover != ''" class="flexy">
                            <img class="cover" :src="cover">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
    export default {
        name: 'Navbar',
        data() {
            return {
                title: '',
                author: '',
                genre: '',
                synopsis: '',
                cover: '',
                name: '',
                description: '',
                publicBool: false

            }
        },
        mounted() {
            this.$store.dispatch('authCheck')
        },
        methods: {
            logout(user) {
                this.$store.dispatch('logout', user)
            },
            goToLogin() {
                this.$store.dispatch('goToLogin')
            },
            goToProfile() {
                this.$store.dispatch('goToProfile')
            },
            goHome() {
                this.$store.dispatch('goHome')
            },
            createBook(title, author, genre, synopsis, cover, user) {
                this.$store.dispatch('createBook', { title: title, author: author, genre: genre, synopsis: synopsis, cover: cover, userId: user.id })
                this.title = '',
                    this.author = '',
                    this.genre = '',
                    this.synopsis = '',
                    this.cover = ''
            },
            createLibrary(name, description, publicBool, user) {
                this.$store.dispatch('createLibrary', { name: name, description: description, public: publicBool, userId: user.id })
                this.name = '',
                    this.description = ''
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            onProfile() {
                return this.$store.state.onProfile
            }
        }
    }
</script>

<style scoped>
    .navbar {
        background-color: indigo;
        height: 10vh;
        display: flex;
        flex-direction: row;
        justify-content: space-between;
    }

    .title {
        color: white;
    }

    .navRight {
        display: flex;
        flex-direction: row;
        justify-content: space-around;
        align-items: baseline;
    }

    button {
        margin: 10px;
    }

    .form-group {
        width: 100%
    }

    .form-control {
        width: 100%
    }

    .btn-primary {
        width: 50%
    }

    .modal-body {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
    }

    .cover {
        height: 20vh
    }

    .flexy {
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
        width: 100%;
    }

    .flexy2 {
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: baseline;
        width: 100%;
        margin: 5px;
    }

    .name {
        color: white;
    }
</style>