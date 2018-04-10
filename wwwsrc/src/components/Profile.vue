<template>
    <div>
        <Navbar></Navbar>
        <div class="profile">
            <div v-for="library in libraries" class="col-sm-6 library">
                <div class="card">
                    <div class="card-body">
                        <h2>{{library.name}}</h2>
                        <h4>{{library.description}}</h4>
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

            }
        },
        mounted() {
            this.$store.dispatch('authProfile')
            this.$store.dispatch('onProfile')
            this.$store.dispatch('getLibraries', this.$store.state.user.id)
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
            }
        }
    }
</script>

<style scoped>
    .profile {
        background-color: rgb(33, 197, 121);
        min-height: 90vh;
        padding-top: 10px
    }

    .card-body {
        background-color: #ffffff;
        background-image: url("https://www.transparenttextures.com/patterns/notebook-dark.png");
    }
</style>