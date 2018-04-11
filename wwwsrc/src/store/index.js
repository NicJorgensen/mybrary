import vue from "vue"
import vuex from "vuex"
import axios from "axios"
import router from "../router"

var production = !window.location.host.includes('localhost')
var baseUrl = production ? '' : '//localhost:5000/'

var auth = axios.create({
    baseURL: baseUrl + "account/",
    timeout: 5000,
    withCredentials: true
})

var api = axios.create({
    baseURL: baseUrl + "api/",
    timeout: 5000,
    withCredentials: true
})

vue.use(vuex)

export default new vuex.Store({
    state: {
        user: {},
        books: [],
        libraries: [],
        libraryBooks: [],
        onProfile: false
    },
    mutations: {
        setUser(state, payload) {
            state.user = payload
        },
        logout(state, payload) {
            state.user = {}
        },
        setBooks(state, payload) {
            state.books = payload
            state.books.sort(function (a, b) { return 0.5 - Math.random() })
        },
        addBook(state, payload) {
            state.books.unshift(payload)
        },
        setLibraries(state, payload) {
            state.libraries = payload
            state.libraries.sort(function (a, b) { return 0.5 - Math.random() })
        },
        addLibrary(state, payload) {
            state.libraries.unshift(payload)
        },
        setLibraryBooks(state, payload) {
            state.libraryBooks = payload
            state.libraryBooks.sort(function (a, b) { return 0.5 - Math.random() })
        },
        addLibraryBook(state, payload) {
            state.libraryBooks.unshift(payload)
        },
        onProfile(state, payload) {
            state.onProfile = true
        },
        offProfile(state, payload) {
            state.onProfile = false
        }
    },
    actions: {
        authenticate({ commit, dispatch }) {
            auth.get('authenticate')
                .then(res => {
                    commit('setUser', res.data)
                    router.push({ name: 'Home' })
                })
                .catch(err => {
                    router.push({ name: 'Login' })
                })
        },
        authCheck({ commit, dispatch }) {
            auth.get('authenticate')
                .then(res => {
                    commit('setUser', res.data)
                })
                .catch(err => {
                    console.log()
                })
        },
        authProfile({ commit, dispatch }) {
            auth.get('authenticate')
                .then(res => {
                    commit('setUser', res.data)
                })
                .catch(err => {
                    router.push({ name: 'Home' })
                    console.log()
                })
        },
        createUser({ commit, dispatch }, payload) {
            auth.post('register', payload)
                .then(res => {
                    console.log("Push it!")
                    router.push({ name: 'Home' })
                })
                .catch(err => {
                    console.log("Invalid username or password")
                    router.push({ name: 'Login' })
                })
        },
        goToLogin({ commit, dispatch }) {
            router.push({ name: 'Login' })
        },
        login({ commit, dispatch }, payload) {
            auth.post('login', payload)
                .then(res => {
                    commit('setUser', {})
                    router.push({ name: 'Home' })
                })
                .catch(err => {
                    console.log('Invalid Username or Password')
                    router.push({ name: 'Login' })
                })
        },
        logout({ commit, dispatch }, payload) {
            auth.delete('logout', payload)
                .then(res => {
                    commit('logout', payload)
                    router.push({ name: 'Home' })
                })
                .catch(err => {
                    console.log('Error logging out.')
                })
        },
        getBooks({ commit, dispatch }) {
            api.get('books')
                .then(res => {
                    commit('setBooks', res.data)
                })
                .catch(err => {
                    console.log('Unable to Retrieve Books.')
                })
        },
        createBook({ commit, dispatch }, payload) {
            api.post('books', payload)
                .then(res => {
                    commit('addBook', res.data)
                })
                .catch(err => {
                    console.log('Unable to Add Book.')
                })
        },
        getLibraries({ commit, dispatch }, payload) {
            api.get('libraries/' + payload, payload)
                .then(res => {
                    commit('setLibraries', res.data)
                })
                .catch(err => {
                    console.log('Unable to Retrieve Libraries.')
                })
        },
        createLibrary({ commit, dispatch }, payload) {
            api.post('libraries', payload)
                .then(res => {
                    commit('addLibrary', res.data)
                })
                .catch(err => {
                    console.log('Unable to Retrieve Libraries.')
                })
        },
        onProfile({ commit, dispatch }) {
            commit('onProfile')
        },
        offProfile({ commit, dispatch }) {
            commit('offProfile')
        },
        goToProfile({ commit, dispatch }) {
            router.push({ name: 'Profile' })
        },
        goHome({ commit, dispatch }) {
            router.push({ name: 'Home' })
        },
        addToLibrary({ commit, dispatch }, payload) {
            api.post('librarybooks', payload)
                .then(res => {
                    commit('addLibraryBook', res.data)
                })
                .catch(err => {
                    console.log('Unable to Post Library Book.')
                })
        },
        getLibraryBooks({ commit, dispatch }, payload) {
            api.get('librarybooks/' + payload, payload)
                .then(res => {
                    commit('setLibraryBooks', res.data)
                })
                .catch(err => {
                    console.log('Unable to Retrieve Library Books.')
                })
        },
        deleteLibrary({ commit, dispatch }, payload) {
            api.delete('libraries/' + payload.libraryId, payload.LibraryId)
                .then(res => {
                    dispatch('getLibraries', payload.userId)
                })
                .catch(err => {
                    console.log('Unable to Delete Library.')
                })
        },
        deleteBook({ commit, dispatch }, payload) {
            api.delete('books/' + payload, payload)
                .then(res => {
                    dispatch('getBooks')
                })
                .catch(err => {
                    console.log('Unable to Delete Book.')
                })
        }
    }
})