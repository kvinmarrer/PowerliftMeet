import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
  standalone: false,
})
export class AppComponent {
  constructor(private translate: TranslateService) {
    translate.setFallbackLang('de');
    translate.use('de');
  }

  changeLanguage(language: any) {
    if (!language) {
      return;
    }
    if (!(language instanceof String)) {
      language = language.detail.value;
    }
    language = language.toLowerCase();
    this.translate?.use(language);
    localStorage.setItem('language', language);
  }
}