import { Observable, throwError as _throw } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpSetting } from './httpSetting';

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse, HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';


const httpOptions = {
	headers: new HttpHeaders({
		'Content-Type': 'application/json',
		'Cache-Control': 'no-cache',
		'Access-Control-Allow-Origin':'*'
	}),
};

@Injectable()
export class HttpService implements HttpInterceptor {
	constructor(private _httpClient: HttpClient) {
	}

	intercept(req: HttpRequest<any>, next: HttpHandler) {
		const httpRequest = req.clone(httpOptions);
		return next.handle(httpRequest);
	}

	get(url: string) {
		url =  url;
		return this._httpClient.get(url, httpOptions)
			.pipe(catchError(this.handleError));
	}

	

	getByType<T>(url: string) {
		url =  url;
		return this._httpClient.get<T>(url, httpOptions)
			.pipe(catchError(this.handleError));
	}

	

	getJSON(url: string): Observable<any> {
		return this._httpClient.get(url)
			.pipe(catchError(this.handleError));
	}

	getJSONByType<T>(url: string): Observable<any> {
		return this._httpClient.get<T>(url)
			.pipe(catchError(this.handleError));
	}

	post(url: string, data: any) {
		url =  url;
		return this._httpClient.post(url, data, httpOptions)
			.pipe(catchError(this.handleError));
	}

	
	handleError(errorResponse: any) {
		let errMsg: string;
		if (errorResponse instanceof HttpErrorResponse) {
			const err = errorResponse.message || JSON.stringify(errorResponse.error);
			errMsg = `${errorResponse.status} - ${errorResponse.statusText || ''} Details: ${err}`;
			console.log(errMsg);
		} else {
			errMsg = errorResponse.message ? errorResponse.message : errorResponse.toString();
			console.log(errMsg);
		}

		return _throw('Deliberate 404');
	}
}
