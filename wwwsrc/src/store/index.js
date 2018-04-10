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
        },
        addBook(state, payload) {
            state.books.unshift(payload)
        },
        setLibraries(state, payload) {
            state.libraries = payload
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
            console.log(payload)
            api.post('books', payload)
                .then(res => {
                    commit('addBook', res.data)
                })
                .catch(err => {
                    console.log('Unable to Add Book.')
                })
        },
        getLibraries({ commit, dispatch }, payload) {
            console.log(payload)
            api.get('libraries/' + payload, payload)
                .then(res => {
                    console.log(res.data)
                    commit('setLibraries', res.data)
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
        }
    }
})