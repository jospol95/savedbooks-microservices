<template>
  <div class="container">
    <form @submit.prevent="login">
      <h2 class="mb-3">Login</h2>
      <div class="input">
        <label for="email">Email address</label>
        <input
          class="form-control"
          type="text"
          name="email"
          placeholder="email@adress.com"
        />
      </div>
      <div class="input">
        <label for="password">Password</label>
        <input
          class="form-control"
          type="password"
          name="password"
          placeholder="password123"
        />
      </div>
      <div class="alternative-option mt-4">
        You don't have an account? <span @click="moveToRegister">Register</span>
      </div>
      <button type="submit" class="mt-4 btn-pers" id="login_button">
        Login
      </button>
      <div
        class="alert alert-warning alert-dismissible fade show mt-5 d-none"
        role="alert"
        id="alert_1"
      >
        Lorem ipsum dolor sit amet consectetur, adipisicing elit.
        <button
          type="button"
          class="btn-close"
          data-bs-dismiss="alert"
          aria-label="Close"
        ></button>
      </div>
    </form>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import {login} from '@/services/AuthService'

@Options({
  data(){
    return {
      email: "",
      password: "",
    };
  },
  props: {
    msg: String
  },
  methods: {
    moveToRegister() {
      this.$router.push("/register");
    },
    login(submitEvent: any) {
      this.email = submitEvent.target.elements.email.value;
      this.password = submitEvent.target.elements.password.value;
      const loginDto = {
        "UserName": this.email,
        "Password": this.password
      };
      login(loginDto).then((response) => {
        console.log(response);
      }).catch((error) => {
        const message = error.response.data;
        console.log(message);
      });
    }
  },
})
export default class LoginView extends Vue {
  msg!: string
}
</script>


