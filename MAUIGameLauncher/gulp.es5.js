'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass')(require('sass'));
gulp.task('styles', function () {
    return gulp.src('C:Users\nickrSourceReposDerPizzaBurscheMAUIGameLauncheradzenMAUIGameLauncherwwwrootscssStyleSheet1.scss').pipe(sass().on('error', sass.logError)).pipe(gulp.dest('C:Users\nickrSourceReposDerPizzaBurscheMAUIGameLauncheradzenMAUIGameLauncherwwwrootcssapp.css'));
});
gulp.task('default', gulp.series['styles']);

