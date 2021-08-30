const routes = [
    {path: '/home', component: home},
    {path: '/department', component: department},
    {path: '/employee', component: employee}
];

const router = new VueRouter({
    routes
});

const app = new Vue({
        router
}).$mount('#app');