import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdusePageComponent } from './produse-page.component';

describe('ProdusePageComponent', () => {
  let component: ProdusePageComponent;
  let fixture: ComponentFixture<ProdusePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProdusePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdusePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
