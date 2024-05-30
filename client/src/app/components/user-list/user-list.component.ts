import { Component, OnDestroy, OnInit } from '@angular/core';
import { APIService } from '../../services/api-service/api.service';
import { IUser } from '../../interfaces/IUser';
import { Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.scss',
})
export class UserListComponent implements OnInit, OnDestroy {
  users: IUser[] = [];
  usersSubscription: Subscription = new Subscription();

  constructor(private apiService: APIService) {}

  ngOnInit(): void {
    this.usersSubscription = this.apiService.fetchUsers().subscribe((users) => {
      this.users = users;
    });
  }

  ngOnDestroy(): void {
    this.usersSubscription.unsubscribe();
  }
}
