import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [HttpClientTestingModule]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve weather forecasts from the server', () => {
    const mockSymbiotes = [
      { id: "qwerty",  name: "Something", iscomplete: "Dontknow" },
      { id: "ytrewq",  name: "Nothing", iscomplete: "Dontknow" }
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/symbiote');
    expect(req.request.method).toEqual('GET');
    req.flush(mockSymbiotes);

    //expect(component.symbiotes).toEqual(mockSymbiotes);
  });
});
