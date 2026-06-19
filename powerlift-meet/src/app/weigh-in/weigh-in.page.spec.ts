import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WeighInPage } from './weigh-in.page';

describe('WeighInPage', () => {
  let component: WeighInPage;
  let fixture: ComponentFixture<WeighInPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(WeighInPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
