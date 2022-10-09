import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PremiumformComponent } from './premiumform.component';

describe('PremiumformComponent', () => {
  let component: PremiumformComponent;
  let fixture: ComponentFixture<PremiumformComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PremiumformComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PremiumformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
