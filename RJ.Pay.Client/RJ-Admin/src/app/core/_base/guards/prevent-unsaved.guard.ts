import { Injectable } from '@angular/core';
import { CanDeactivate} from '@angular/router';
import { ProfileComponent } from 'src/app/views/panel/pages/commonp/pages/profile/profile.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedGuard implements CanDeactivate<ProfileComponent> {

  canDeactivate(component: ProfileComponent) {
    if (component.editForm.dirty) {
        return confirm('شما تغییراتی ایجاد کرده اید با خروج تغیرات ذخیره نمیشود');
    }
    return true;
  }
}
