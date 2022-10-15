import { TestBed } from '@angular/core/testing';

import { DetaliiComandaService } from './detalii-comanda.service';

describe('DetaliiComandaService', () => {
  let service: DetaliiComandaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DetaliiComandaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
