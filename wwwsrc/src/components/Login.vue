<template>
  <div class="bg">
    <div class="login col-sm-8">
      <h1>Welcome to My&#8226;brary</h1>
      <form v-if="showLogin == true" @submit.prevent="login()" class="form-group">
        <h2>LOGIN</h2>
        <input type="text" v-model="user.email" placeholder="Email" class="form-control">
        <input type="password" v-model="user.password" placeholder="Password" class="form-control">
        <button type="submit" class="btn submit">Submit</button>
      </form>

      <form v-if="showLogin == false" @submit.prevent="createUser()" class="form-group">
        <h2>CREATE ACCOUNT</h2>
        <input type="text" v-model="newUser.name" placeholder="Username" class="form-control">
        <input type="text" v-model="newUser.email" placeholder="Email" class="form-control">
        <input type="password" v-model="newUser.password" placeholder="Password" class="form-control">
        <input type="password" v-model="newUser.confirmPassword" placeholder="Confirm Password" class="form-control">
        <button type="submit" @click="showLogin = true" class="btn submit">Submit</button>
      </form>

      <div class="d-flex justify-content-center">
        <div class="bg-1">
          <button @click="showLogin = false" class="btn btn-link">Create User</button>
          <button @click="showLogin = true" class="btn btn-link">Login</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Login',
    data() {
      return {
        showLogin: true,
        user: {
          email: '',
          password: ''
        },
        newUser: {
          name: '',
          email: '',
          password: '',
          confirmPassword: ''
        }
      }
    },
    mounted(){
      this.$store.dispatch('authenticate')
    },
    methods: {
      login() {
        this.$store.dispatch('login', this.user)
        this.resetFields()
      },
      createUser() {
        if (this.newUser.password !== this.newUser.confirmPassword) {
          this.resetFields()
          alert("Passwords do not match!")
          return this.showLogin = false
        }
        this.$store.dispatch('createUser', this.newUser)
        this.resetFields()
      },
      resetFields() {
        Object.assign(this.$data, this.$options.data.call(this));
      }
    }
  }
</script>


<style scoped>
  .bg {
    height: 100vh;
    background-image: url(https://images.unsplash.com/photo-1516979187457-637abb4f9353?ixlib=rb-0.3.5&ixid=eyJhcHBfaWQiOjEyMDd9&s=0c4b5fcc53abd6158286dc86a9be4bee&auto=format&fit=crop&w=1350&q=80);
    background-position: center;
    background-size: cover;
  }

  .login {
    display: flex;
    flex-direction: column;
    justify-content: center;
    height: 100vh
  }

  .form-group {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center
  }

  .form-control {
    width: 50%;
    margin: 5px
  }

  .bg-1 {
    background-color: rgba(170, 168, 168, 0.5);
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    width: 70%;
    border-radius: 30px
  }

  .btn-link {
    color: indigo;
    font-weight: 700
  }

  .submit {
    width: 20%;
    background-color: indigo;
    font-weight: 600;
    color: white
  }
</style>