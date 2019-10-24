#!/bin/bash

src_path=admin.adstack.tv
s3_bucket=brainshark.sarslan.net
aws_profile=sarslan
stage=production

cd frontend
ng build -c $stage
aws s3 sync ./dist/ui s3://$s3_bucket --acl public-read --profile $aws_profile
xdg-open https://$s3_bucket &
