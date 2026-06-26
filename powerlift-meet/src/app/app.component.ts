import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Auth } from './services/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
  standalone: false,
})
export class AppComponent implements OnInit {
  constructor(private translate: TranslateService, private auth: Auth, private router: Router) {
    translate.setFallbackLang('de');
    translate.use('de');
  }

  ngOnInit() {
    const token = new URLSearchParams(window.location.search).get('token');
    if (token) {
      localStorage.setItem('token', token);
      this.router.navigate(['/tabs/home']);
    }
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

  logout() {
    this.auth.logout();
  }
}