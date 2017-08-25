import { Http } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { sharedConfig } from './app.module';



@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [   BrowserModule,                     
        ...sharedConfig.imports,
        
    ],

    providers: [          
        sharedConfig.providers
        
    ]
})
export class AppModule {
}
