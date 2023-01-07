const gulp = require('gulp');
const sass = require('gulp-sass')(require('sass'));
gulp.task('styles', () => {
    return gulp.src('C:\Users\nickr\Source\Repos\DerPizzaBursche\MAUIGameLauncheradzen\MAUIGameLauncher\wwwroot\scss\StyleSheet1.scss').pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('C:\Users\nickr\Source\Repos\DerPizzaBursche\MAUIGameLauncheradzen\MAUIGameLauncher\wwwroot\css\app.css'))
});
gulp.task('default', gulp.series['styles']);