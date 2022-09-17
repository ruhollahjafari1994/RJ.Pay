var ROUTES_INDEX = {"name":"<root>","kind":"module","className":"AppModule","children":[{"name":"routes","filename":"src/app/app-routing.module.ts","module":"AppRoutingModule","children":[{"path":"auth","redirectTo":"/auth/login","pathMatch":"full"},{"path":"auth","loadChildren":"./views/auth/auth.module#AuthModule","children":[{"kind":"module","children":[{"name":"routes","filename":"src/app/views/auth/auth-routing.module.ts","module":"AuthRoutingModule","children":[{"path":"","component":"AuthComponent","children":[{"path":"login","canActivate":["LoginRedirectGuard"],"component":"LoginComponent","data":{"title":["ورودبهپنلکاربری"]}},{"path":"register","component":"RegisterComponent","data":{"title":["ثبتنامدرمادپی"]}}]}],"kind":"module"}],"module":"AuthModule"}]},{"path":"panel","loadChildren":"./views/panel/panel.module#PanelModule","children":[{"kind":"module","children":[{"name":"routes","filename":"src/app/views/panel/panel-routing.module.ts","module":"PanelRoutingModule","children":[{"path":"admin","component":"PanelComponent","loadChildren":"./pages/admin/admin.module#AdminModule","children":[{"kind":"module","children":[{"name":"routes","filename":"src/app/views/panel/pages/admin/admin-routing.module.ts","module":"AdminRoutingModule","children":[{"path":"","component":"AdminComponent","children":[{"path":"dashboard","canActivate":["AuthGuard"],"component":"DashboardComponent","data":{"roles":["Admin"],"title":["داشبوردمدیریت"]}},{"path":"users/usersmanagement","canActivate":["AuthGuard"],"component":"UsersManagementComponent","data":{"roles":["Admin"],"title":["مدیریتکاربران"]}}]}],"kind":"module"}],"module":"AdminModule"}]},{"path":"user","component":"PanelComponent","loadChildren":"./pages/user/user.module#UserModule","children":[{"kind":"module","children":[{"name":"routes","filename":"src/app/views/panel/pages/user/user-routing.module.ts","module":"UserRoutingModule","children":[{"path":"","component":"UserComponent","children":[{"path":"dashboard","canActivate":["AuthGuard"],"component":"UserDashboardComponent","data":{"roles":["User"],"title":["داشبوردکاربر"]}},{"path":"gate","canActivate":["AuthGuard"],"resolve":{"gateswallets":"GateResolver"},"component":"GateManageComponent","data":{"roles":["User"],"title":["مدیریتدرگاههایپرداخت"]}},{"path":"gate/edit/:gateId","canActivate":["AuthGuard"],"resolve":{"gatewallets":"GateEditResolver"},"component":"GateEditComponent","data":{"roles":["User"],"title":["ویرایشدرگاهپرداخت"]}},{"path":"userinfo/profile","canActivate":["AuthGuard"],"component":"ProfileComponent","data":{"roles":["User","Admin","AdminBlog","Blog","Accountant"],"title":["پروفایلکاربری"]},"resolve":{"user":"UserProfileResolver"},"canDeactivate":["PreventUnsavedGuard"]},{"path":"userinfo/documents","canActivate":["AuthGuard"],"resolve":{"documents":"DocumentResolver"},"component":"DocumentComponent","data":{"roles":["User"],"title":["ارسالمدارکشناسایی"]}},{"path":"notification","canActivate":["AuthGuard"],"resolve":{"notify":"NotificationResolver"},"component":"NotificationComponent","data":{"roles":["User"],"title":["تنظیماتاطلاعرسانی"]}},{"path":"bankcard","canActivate":["AuthGuard"],"resolve":{"bankcards":"BankCardResolver"},"component":"ManageBankCardComponent","data":{"roles":["User"],"title":["مدیریتکارتهایبانکی"]}},{"path":"wallet","canActivate":["AuthGuard"],"resolve":{"wallets":"WalletResolver"},"component":"ManageWalletComponent","data":{"roles":["User"],"title":["مدیریتکیفپول"]}},{"path":"tickets","canActivate":["AuthGuard"],"resolve":{"tickets":"TicketResolver"},"component":"ManageTicketComponent","data":{"roles":["User"],"title":["پشتیبانی"]},"children":[{"path":"overview/:ticketId","component":"DetailTicketComponent","resolve":{"ticket":"TicketOverviewResolver"},"data":{"roles":["User"],"title":["مشاهدهیتیکت"]}}]},{"path":"easypay","canActivate":["AuthGuard"],"component":"EasypayManageComponent","data":{"roles":["User"],"title":["مدیریتایزیپیها"]}},{"path":"easypay/add","canActivate":["AuthGuard"],"resolve":{"gateswallets":"GateResolver"},"component":"EasypayAddComponent","data":{"roles":["User"],"title":["افزودنایزیپیها"]}},{"path":"easypay/edit/:easypayId","canActivate":["AuthGuard"],"resolve":{"easypayGatesWallets":"EasyPayEditResolver"},"component":"EasypayEditComponent","data":{"roles":["User"],"title":["ویرایشایزیپی"]}}]}],"kind":"module"}],"module":"UserModule"}]},{"path":"blog","component":"PanelComponent","loadChildren":"./pages/blog/blog.module#BlogModule","children":[{"kind":"module","children":[{"name":"routes","filename":"src/app/views/panel/pages/blog/blog-routing.module.ts","module":"BlogRoutingModule","children":[{"path":"","component":"BlogComponent","children":[{"path":"dashboard","canActivate":["AuthGuard"],"component":"BlogDashboardComponent","data":{"roles":["Blog","AdminBlog"],"title":["داشبوردبلاگر"]}},{"path":"bloggroup","canActivate":["AuthGuard"],"component":"BlogGroupManageComponent","data":{"roles":["Admin","AdminBlog","Blog"],"title":["مدیریتدستهبدنیهایبلاگ"]}},{"path":"bloggroup/add","canActivate":["AuthGuard"],"resolve":{"bloggroups":"BlogGroupResolver"},"component":"BlogGroupAddComponent","data":{"roles":["Admin","AdminBlog"],"title":["افزودندستهبندیبلاگ"]}},{"path":"bloggroup/edit/:bloggroupId","canActivate":["AuthGuard"],"resolve":{"bloggroups":"BlogGroupResolver"},"component":"BlogGroupEditComponent","data":{"roles":["Admin","AdminBlog"],"title":["ویرایشدستهبندیبلاگ"]}},{"path":"blog","canActivate":["AuthGuard"],"resolve":{"blogs":"BlogResolver"},"component":"BlogManageComponent","data":{"roles":["Admin","AdminBlog","Blog"],"title":["مدیریتبلاگها"]}},{"path":"blog/add","canActivate":["AuthGuard"],"resolve":{"bloggroups":"BlogGroupResolver"},"component":"BlogAddComponent","data":{"roles":["Admin","AdminBlog","Blog"],"title":["افزودنبلاگ"]}},{"path":"blog/edit/:blogId","canActivate":["AuthGuard"],"resolve":{"bloggroups":"BlogGroupResolver"},"component":"BlogEditComponent","data":{"roles":["Admin","AdminBlog","Blog"],"title":["ویرایشبلاگ"]}}]}],"kind":"module"}],"module":"BlogModule"}]},{"path":"accountant","component":"PanelComponent","loadChildren":"./pages/accountant/accountant.module#AccountantModule","children":[{"kind":"module","children":[],"module":"AccountantModule"}]}],"kind":"module"}],"module":"PanelModule"}]},{"path":"**","redirectTo":"/auth/login","pathMatch":"full"}],"kind":"module"}]}
