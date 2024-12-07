import { Injectable } from '@angular/core';
import { AddBlogpost } from '../models/add-blog-post.model';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/blog-post.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { UpdateBlogPost } from '../models/update-blog-post.model';

@Injectable({
  providedIn: 'root',
})
export class BlogPostService {
  constructor(private http: HttpClient) {}

  createBlogPost(data: AddBlogpost): Observable<BlogPost> {
    return this.http.post<BlogPost>(
      `${environment.apiBaseUrl}/api/blogpost?addAuth=true`,
      data
    );
  }

  getAllBlogPosts(): Observable<BlogPost[]> {
    return this.http.get<BlogPost[]>(`${environment.apiBaseUrl}/api/blogpost`);
  }

  getBlogPostById(id: string): Observable<BlogPost> {
    return this.http.get<BlogPost>(
      `${environment.apiBaseUrl}/api/blogpost/${id}`
    );
  }

  updateBlogPostById(
    id: string,
    updatedBlogPost: UpdateBlogPost
  ): Observable<BlogPost> {
    return this.http.put<BlogPost>(
      `${environment.apiBaseUrl}/api/blogpost/${id}?addAuth=true`,
      updatedBlogPost
    );
  }

  deleteBlogPostById(id: string): Observable<BlogPost> {
    return this.http.delete<BlogPost>(
      `${environment.apiBaseUrl}/api/blogpost/${id}?addAuth=true`
    );
  }

  getBlogPostByUrlHandle(urlHandle: string): Observable<BlogPost> {
    return this.http.get<BlogPost>(
      `${environment.apiBaseUrl}/api/blogpost/${urlHandle}`
    );
  }
}
