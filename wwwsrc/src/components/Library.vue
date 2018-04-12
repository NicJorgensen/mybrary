<template>
    <div class="library">
        <div class="card">
            <div class="card-body" @click="getLibraryBooks(library.id)" data-toggle="modal" :data-target="'#' + library.id">
                <h2>{{library.name}}</h2>
                <h4>{{library.description}}</h4>
            </div>
        </div>

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
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
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
        name: 'Library',
        data() {
            return {

            }
        },
        methods: {
            getLibraryBooks(libraryId) {
                this.$store.dispatch('getLibraryBooks', libraryId)
            }
        },
        computed: {
            libraryBooks() {
                return this.$store.state.libraryBooks
            }
        },
        props: ['library', 'id']
    }
</script>

<style scoped>
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
        margin-left: 10px;
        margin-right: 10px;
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
</style>