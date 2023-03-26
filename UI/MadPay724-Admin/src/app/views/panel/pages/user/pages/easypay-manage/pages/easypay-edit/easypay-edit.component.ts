import { Component, OnInit, OnDestroy } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import _ from 'lodash';
import { EasyPayGatesWallets } from 'src/app/data/models/user/easyPayGatesWallets';
import { EasyPay } from 'src/app/data/models/user/easyPay';
import { EasyPayService } from 'src/app/core/_services/panel/user/easyPay.service';
import { Gate } from 'src/app/data/models/user/gate';

@Component({
  selector: 'app-easypay-edit',
  templateUrl: './easypay-edit.component.html',
  styleUrls: ['./easypay-edit.component.css']
})
export class EasypayEditComponent implements OnInit, OnDestroy {
  easypayGatesWallets: EasyPayGatesWallets;
  subManager = new Subscription();
  easypay: EasyPay;

  constructor(
    private alertService: ToastrService, private route: ActivatedRoute,
    private router: Router, public easypayService: EasyPayService) { }

  ngOnInit() {
    this.subManager.add(
      this.route.data.subscribe(data => {
        this.easypayGatesWallets = data['easypayGatesWallets'];
        this.easypayService.populateForm(this.easypayGatesWallets.easyPay);
      })
    );
  }
  getGates(): Gate[] {
    return _.filter(this.easypayGatesWallets.gates, function (n) {
      return n.isActive;
    });
  }
  ngOnDestroy() {
    this.subManager.unsubscribe();
  }
  onClear() {
    this.easypayService.easypayForm.reset({
      walletGateId: '',
      isWallet: true,
      name: '',
      price: 0,
      text: '',
      isCoupon: false,
      isUserEmail: true,
      isUserName: true,
      isUserPhone: true,
      isUserText: true,
      isUserEmailRequired: false,
      isUserNameRequired: false,
      isUserPhoneRequired: false,
      isUserTextRequired: false,
      userEmailExplain: 'ایمیل',
      userNameExplain: 'نام',
      userPhoneExplain: 'شماره تماس',
      userTextExplain: 'توضیحات',
      isCountLimit: false,
      countLimit: 0,
      returnSuccess: '',
      returnFail: ''
 });
    this.router.navigate(['/panel/user/easypay']);
  }
  onSubmit() {
    if (this.easypayService.easypayForm.valid) {
      this.easypay = Object.assign({}, this.easypayService.easypayForm.value);
      this.easypayService.updateEasyPay(this.easypay, this.easypay.id).subscribe(() => {
        this.alertService.success('ایزی پی شما با موفقیت ویرایش شد', 'موفق');
        this.onClear();
      }, error => {
        this.alertService.error(error, 'خطا در ویرایش ایزی پی ');
      });
    } else {
      this.alertService.warning('اطلاعات ایزی پی را به درستی وارد کنید', 'خطا');
    }
  }

  getIsWallet(): boolean {
    if (this.easypayService.easypayForm.get('isWallet').value === 'true'
      || this.easypayService.easypayForm.get('isWallet').value === true) {
      return true;
    } else {
      return false;
    }
  }
}
