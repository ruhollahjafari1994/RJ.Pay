import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import {
  NgxUiLoaderModule,
  NgxUiLoaderRouterModule, NgxUiLoaderHttpModule, POSITION, SPINNER, PB_DIRECTION, NgxUiLoaderConfig
} from 'ngx-ui-loader';
import { NotyfToast } from './Shared/Animation/notyf';
import { ErrorInterceptorProvider } from './core/_config/error.interceptor';
import { TitleService } from './core/_services/common/title.service';
import { MpPreloadingStrategy } from './core/_config/mpPreloadingStrategy';
import { HeaderComponent } from './views/layout/header/header.component';
import { SearchBarComponent } from './views/layout/search-bar/search-bar.component';
import { FooterComponent } from './views/layout/footer/footer.component';
import { SlidingBarComponent } from './views/layout/sliding-bar/sliding-bar.component';
import { StyleScriptService } from './core/_services/common/styleScript.service';
import { FormsModule } from '@angular/forms';
import { LayoutService } from './core/_services/layout/layout.service';
import { environment } from 'src/environments/environment.prod';
import { PersianCalendarService } from './core/_base/pipe/PersianDatePipe/persian-date.service';
import { SeoService } from './core/_services/common/seo.service';
import { ServiceWorkerModule } from '@angular/service-worker';



const ngxUiLoaderConfig: NgxUiLoaderConfig = {
  pbColor: 'red',
  //
  bgsColor: 'red',
  bgsPosition: POSITION.bottomRight,
  bgsSize: 70,
  //
  fgsPosition: POSITION.centerCenter,
  fgsSize: 100,
  fgsColor: 'red',
  bgsType: SPINNER.doubleBounce,
  fgsType: SPINNER.doubleBounce,
  pbDirection: PB_DIRECTION.leftToRight,
  pbThickness: 2
  , overlayColor: 'rgba(255,255,255,.95)'
};
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SearchBarComponent,
    SlidingBarComponent,
    NotyfToast
  ],
  imports: [
    FormsModule,
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-center',
      preventDuplicates: true,
      progressBar: true,
      progressAnimation: 'decreasing'
    }),
    HttpClientModule,
    NgxUiLoaderModule.forRoot(ngxUiLoaderConfig),
    NgxUiLoaderRouterModule,
    NgxUiLoaderHttpModule.forRoot({
      showForeground: true ,
      exclude: [environment.apiUrl + environment.apiV1 + 'site/layout/sidebar/data']
    }),
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [
    MpPreloadingStrategy,
    ErrorInterceptorProvider,
    TitleService,
    StyleScriptService,
    LayoutService,
    PersianCalendarService,
    SeoService
  ],
  entryComponents: [NotyfToast],
  bootstrap: [AppComponent]
})
export class AppModule { }
