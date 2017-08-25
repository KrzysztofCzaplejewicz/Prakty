import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { sharedConfig } from './app.module';

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        
        ...sharedConfig.imports,
        ServerModule,
    ],
    providers: [sharedConfig.providers]
    
})
export class AppModule {
}
