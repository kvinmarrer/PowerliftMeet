import { Component, Input } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { CommonModule } from '@angular/common';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  standalone: true,
  imports: [IonicModule, TranslateModule, CommonModule],
})
export class HeaderComponent {
  @Input() icon?: string;
  @Input() title?: string;
  @Input() subtitle?: string;
  translate?: TranslateService;

  constructor(translateService: TranslateService) {
    this.translate = translateService;
    this.translate.setFallbackLang('en');

    this.initializeTranslation();
  }

  initializeTranslation() {
    const localStoredLang = localStorage.getItem('language');
    if (localStoredLang) {
      this.translate?.use(localStoredLang);
      return;
    }

    const browserLang = this.translate?.getBrowserLang();
    const langToStore = browserLang?.match(/en|de/) ? browserLang : 'en';
    localStorage.setItem('language', langToStore);
    this.translate?.use(langToStore);
  }

}
