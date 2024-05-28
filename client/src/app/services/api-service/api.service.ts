import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { baseUrl, serverPaths } from '../../constants/api';
import { IUser } from '../../interfaces/IUser';
import { IInsurancePolicy } from '../../interfaces/IInsurancePolicy';

@Injectable({
  providedIn: 'root',
})
export class APIService {
  // page: number = 1;
  // perPage: number = 5;
  constructor(private http: HttpClient) {}

  private get<T>(endpoint: string): Observable<T[]> {
    return this.http
      .get<T[]>(
        `${baseUrl}/${endpoint}`//?_page=${this.page}&_per_page=${this.perPage}`
      )
      .pipe(
        catchError<any, Observable<T[]>>((error) => {
          console.error(error);
          return new Observable<never>();
        })
      );
  }

  private getById<T>(endpoint: string, id: number): Observable<T> {
    return this.http.get<T>(`${baseUrl}/${endpoint}/${id}`).pipe(
      catchError<any, Observable<T>>((error) => {
        console.error(error);
        return new Observable<never>();
      })
    );
  }

  private post<T>(endpoint: string, data: any): Observable<T> {
    return this.http.post<T>(`${baseUrl}/${endpoint}`, data).pipe(
      catchError<any, Observable<T>>((error) => {
        console.error(error);
        return new Observable<never>();
      })
    );
  }

  private put<T>(endpoint: string, data: any): Observable<T> {
    return this.http.put<T>(`${baseUrl}/${endpoint}`, data).pipe(
      catchError<any, Observable<T>>((error) => {
        console.error(error);
        return new Observable<never>();
      })
    );
  }

  private delete<T>(endpoint: string): Observable<T> {
    return this.http.delete<T>(`${baseUrl}/${endpoint}`).pipe(
      catchError<any, Observable<T>>((error) => {
        console.error(error);
        return new Observable<never>();
      })
    );
  }

  fetchUsers(): Observable<IUser[]> {
    return this.get<IUser>(serverPaths.user);
  }

  fetchInsurancePolicies(): Observable<IInsurancePolicy[]> {
    return this.get<IInsurancePolicy>(serverPaths.insurancePolicy);
  }

  fetchUserById(id: number): Observable<IUser> {
    return this.getById<IUser>(serverPaths.user, id);
  }

  fetchInsurancePolicyById(id: number): Observable<IInsurancePolicy> {
    return this.getById<IInsurancePolicy>(serverPaths.insurancePolicy, id);
  }

  createUser(user: IUser): Observable<IUser> {
    return this.post<IUser>(serverPaths.user, user);
  }

  createInsurancePolicy(insurancePolicy: IInsurancePolicy): Observable<IInsurancePolicy> {
    return this.post<IInsurancePolicy>(serverPaths.insurancePolicy, insurancePolicy);
  }

  updateUser(user: IUser): Observable<IUser> {
    return this.put<IUser>(serverPaths.user, user);
  }

  updateInsurancePolicy(insurancePolicy: IInsurancePolicy): Observable<IInsurancePolicy> {
    return this.put<IInsurancePolicy>(serverPaths.insurancePolicy, insurancePolicy);
  }

  deleteUser(id: number): Observable<IUser> {
    return this.delete<IUser>(`${serverPaths.user}/${id}`);
  }

  deleteInsurancePolicy(id: number): Observable<IInsurancePolicy> {
    return this.delete<IInsurancePolicy>(`${serverPaths.insurancePolicy}/${id}`);
  }

  // setPagination(page: number, perPage: number): void {
  //   this.page = page;
  //   this.perPage = perPage;
  // }
}
