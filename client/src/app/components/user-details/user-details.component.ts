import { Component, OnDestroy, OnInit } from '@angular/core';
import { IUser } from '../../interfaces/IUser';
import { Subscription } from 'rxjs';
import { APIService } from '../../services/api-service/api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-details',
  standalone: true,
  imports: [],
  templateUrl: './user-details.component.html',
  styleUrl: './user-details.component.scss',
})
export class UserDetailsComponent implements OnInit, OnDestroy {
  user: IUser | undefined = undefined;
  userDetailsSubscription: Subscription = new Subscription();
  userId: number | null = null;

  constructor(private apiService: APIService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const routeParamId = this.route.snapshot.paramMap.get('id');
    const numberId = routeParamId !== null ? Number(routeParamId) : null;
    const notNumber = numberId === null || isNaN(numberId);
    if (notNumber) return;
    this.userId = numberId;
    
    this.userDetailsSubscription = this.apiService
      .fetchUserById(numberId)
      .subscribe((user: IUser) => {
        this.user = user;
      });
  }

  ngOnDestroy(): void {
    this.userDetailsSubscription.unsubscribe();
  }
}
