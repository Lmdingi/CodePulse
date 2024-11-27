import { Injectable } from '@angular/core';
import { AddBlogpost } from '../models/add-blog-post.model';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/blog-post.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class BlogPostService {
  constructor(private http: HttpClient) {}

  createBlogPost(data: AddBlogpost): Observable<BlogPost> {
    console.log("===========");
    
    return this.http.post<BlogPost>(
      `${environment.apiBaseUrl}/api/blogpost`,
      data
    );
  }
}
