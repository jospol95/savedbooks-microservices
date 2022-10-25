import Login from "@/components/Login.vue";
import {Vue} from "vue-class-component";
import {createRouter, createWebHistory} from "vue-router";


const routes = [
    {
        path: "/",
        name: "login",
        component: Login,
    },
    // {
    //     path: "/register",
    //     name: "register",
    //     component: () =>
    //         import(/* webpackChunkName: "about" */ "../views/RegisterView.vue"),
    // },
    // {
    //     path: "/dashboard",
    //     name: "dashboard",
    //     component: () =>
    //         import(/* webpackChunkName: "about" */ "../views/DashboardView.vue"),
    //     meta: {
    //         authRequired: true,
    //     },
    // },
];

const router = createRouter ({
    history: createWebHistory(),
    routes // short for `routes: routes`
})

export default router

